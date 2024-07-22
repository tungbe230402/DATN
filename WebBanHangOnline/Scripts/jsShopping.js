$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var selectedColor = $('.color-buttons .color-button.active').text();
        var selectedSize = $('.size-buttons .size-button.active').text();
        if (!selectedColor) {
            alert('Vui lòng chọn màu sắc trước khi thêm vào giỏ hàng!');
            return; // Dừng lại nếu chưa chọn đủ color hoặc size
        }
        if (!selectedSize) {
            alert('Vui lòng chọn kích cỡ trước khi thêm vào giỏ hàng!');
            return;
        }
        var quatity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '') {
            quatity = parseInt(tQuantity);
        }

        //alert(id + " " + quatity)
        $.ajax({
            url: '/ShoppingCart/AddToCart',
            type: 'POST',
            data: { id: id, quantity: quatity, color: selectedColor, size: selectedSize },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.Count);
                    alert(rs.msg);
                }
            }
        });
    });

    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data("id");
        var color = $(this).data('color');
        var size = $(this).data('size');
        var quantity = $('#Quantity_' + id + '_' + color + '_' + size).val();
        Update(id, color, size, quantity);
    });

    $('body').on('click', '.btnDeleteAll', function (e) {
        e.preventDefault();
        var conf = confirm('Bạn có chắc muốn xóa hết sản phẩm trong giỏ hàng?');
        if (conf == true) {
            DeleteAll();
        }
    });

    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var color = $(this).data('color');
        var size = $(this).data('size');
        var conf = confirm('Bạn có chắc muốn xóa sản phẩm này khỏi giỏ hàng?');
        if (conf == true) {
            $.ajax({
                url: '/ShoppingCart/Delete',
                type: 'POST',
                data: { id: id, color: color, size: size },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.Count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }
    });

});


function ShowCount() {
    $.ajax({
        url: '/ShoppingCart/ShowCount',
        type: 'GET',
        success: function (rs) {
            $('#checkout_items').html(rs.Count);
        }
    });
}

function DeleteAll() {
    $.ajax({
        url: '/ShoppingCart/DeleteAll',
        type: 'POST',
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
                ShowCount();
            }
        }
    });
}

function Update(id, color, size, quantity) {
    if (quantity > 0) {
        $.ajax({
            url: '/ShoppingCart/Update',
            type: 'POST',
            data: { id: id, color: color, size: size, quantity: quantity },
            success: function (rs) {
                if (rs.Success) {
                    LoadCart();
                }
            }
        });
    }
    else {
        alert("Số lượng tối thiểu phải là 1");
        LoadCart();
    }
}

function LoadCart() {
    $.ajax({
        url: '/ShoppingCart/Partial_Item_Cart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}