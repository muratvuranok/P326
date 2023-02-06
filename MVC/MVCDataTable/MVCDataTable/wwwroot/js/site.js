jQuery(document).ready(function ($) {

    $('.add_to_cart_button').on('click', function () {
        var id = $(this).data('elma');


        $.ajax({
            url: "/cart/add/" + id,
            method: "POST",
            success: (data) => { console.log(data) },
            error: (err) => { console.log(err) }
        });


    })

})