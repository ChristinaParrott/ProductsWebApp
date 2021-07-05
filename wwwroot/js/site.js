$(function () {
    console.log("document ready");
    $(document).on("click", ".edit-product-button", function () {
        var productID = $(this).val();

        $.ajax({
            type: 'json',
            data: {
                "id": productID
            },
            url: '/product/ShowDetailsJSON',
            success: function (data) {
                $("#modal-input-Id").val(data.id);
                $("#modal-input-Name").val(data.name);
                $("#modal-input-Price").val(data.price);
                $("#modal-input-Description").val(data.description);
            }
        })
    });

    $(document).on("click", ".detail-product-button", function () {
        var productID = $(this).val();

        $.ajax({
            type: 'json',
            data: {
                "id": productID
            },
            url: '/product/ShowDetailsJSON',
            success: function (data) {
                $("#detail-modal-input-Id").val(data.id);
                $("#detail-modal-input-Name").val(data.name);
                $("#detail-modal-input-Price").val(data.price);
                $("#detail-modal-input-Description").val(data.description);
            }
        })
    });

    $("#save-button").click(function () {
        var Product = {
            "Id": $("#modal-input-Id").val(),
            "Name": $("#modal-input-Name").val(),
            "Price": $("#modal-input-Price").val(),
            "Description": $("#modal-input-Description").val()
        };
        $.ajax({
            type: 'json',
            data: Product,
            url: '/product/ProcessEditReturnPartial',
            success: function (data) {
                $("#card-number-" + Product.Id).html(data);
            }
        })
        
    })
    
});