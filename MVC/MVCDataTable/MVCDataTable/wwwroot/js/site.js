jQuery(document).ready(function ($) {

    $('.add_to_cart_button').on('click', function () {
        var id = $(this).data('elma');

        $.ajax({
            url: "/cart/add/" + id,
            method: "POST",
            success: (data) => { GetCart(); },
            error: (err) => { console.log(err) }
        });
    })


    function GetCart() {

        $.getJSON('/cart/getall', function (data) {
            let cart = [];
            var total = 0;
            var count = 0; 
           
            $.each(data, (key, value) => {

                total += value.total;
                count += value.count;

                var template = ` 
                    <div class="cart-product clearfix">
                        <div class="cart-product-image">
                            <a class="cart-product-img" href="#">
                                <img width="300" height="300" src="images/products/product_60x60.jpg" alt=""/>
                            </a>
                        </div>
                        <div class="cart-product-details">
                            <div class="cart-product-title">
                                <a href="#">${value.productName}</a>
                            </div>
                            <div class="cart-product-quantity-price">
                                ${value.count} x <span class="amount">&pound;${value.total}</span>
                            </div>
                        </div>
                        <a href="#" class="remove" title="Remove this item">&times;</a>
                    </div>`;
                cart.push(template);
            })


            let p1 = `
                <div class="minicart">
                    <div class="minicart-header">
                        ${count} items in the shopping cart
                    </div>
                <div class="minicart-body">`;

            let p2 = `
                </div>
                    <div class="minicart-footer">
                        <div class="minicart-total">
                            Cart Subtotal <span class="amount">&pound;${total}</span>
                        </div>
                        <div class="minicart-actions clearfix">
                            <a class="viewcart-button button" href="#">
                                <span class="text">View Cart</span>
                            </a>
                            <a class="checkout-button button" href="#">
                                <span class="text">Checkout</span>
                            </a>
                        </div>
                    </div>
                </div>`

            $('#cart-span').html(count)
            $('.minicart-side-content').html(`${p1} ${cart.join(' ')} ${p2}`);

        })
    }

    GetCart();
})