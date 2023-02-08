$(() => {
    $('.cart').on('click', (e) => {
        let curentItem = e.currentTarget;


        $.ajax({
            url: '/cart/add/1',
            method: 'post',
            success: (data) => { console.log(data) },
            error: (err) => { console.log(err) }
        });
    });


    function GetAll() {
        $.getJSON('/cart/getall', (data) => {

            console.log(data)
        })
    }
    GetAll();

    $('.delete').on('click', (e) => {
        let curentItem = e.currentTarget;
    });

    $('.increase').on('click', (e) => {
        let curentItem = e.currentTarget;
    });

    $('.decrease').on('click', (e) => {
        let curentItem = e.currentTarget;
    });
})

    //< li >
    //                    <div class="sc-productwrap">
    //                        <a href="product_details.html" class="sc-product-thumb">
    //                            <img src="~/assets/images/index1/shopcart01.jpg" alt="Product" class="img-fluid">
    //                        </a>
    //                        <div class="sc-product-details">
    //                            <a href="product_details.html" class="sc-product-ttl">Black Gray Hooded Jacket</a>
    //                            <p class="sc-product-sz">Size : Medium</p>
    //                        </div>
    //                    </div>
    //                    <div class="sc-quantity">
    //                        1X <span class="sc-price"> $1,120</span>
    //                    </div>
    //                    <a href="javascript:void(0);" class="sc-produc-remove">
    //                        <img src="~/assets/images/index1/svg/cut.svg" alt="icon">
    //                    </a>
    //                </li >
    //                <li>
    //                    <div class="sc-productwrap">
    //                        <a href="product_details.html" class="sc-product-thumb">
    //                            <img src="~/assets/images/index1/shopcart02.jpg" alt="Product" class="img-fluid">
    //                        </a>
    //                        <div class="sc-product-details">
    //                            <a href="product_details.html" class="sc-product-ttl">Kids Yellow Padded Jacket</a>
    //                            <p class="sc-product-sz">Size : Medium</p>
    //                        </div>
    //                    </div>
    //                    <div class="sc-quantity">
    //                        1X <span class="sc-price"> $860</span>
    //                    </div>
    //                    <a href="javascript:void(0);" class="sc-produc-remove">
    //                        <img src="~/assets/images/index1/svg/cut.svg" alt="icon">
    //                    </a>
    //                </li>
    //                <li>
    //                    <div class="sc-productwrap">
    //                        <a href="product_details.html" class="sc-product-thumb">
    //                            <img src="~/assets/images/index1/shopcart03.jpg" alt="Product" class="img-fluid">
    //                        </a>
    //                        <div class="sc-product-details">
    //                            <a href="product_details.html" class="sc-product-ttl">Dark Olive Padded Jacket</a>
    //                            <p class="sc-product-sz">Size : Medium</p>
    //                        </div>
    //                    </div>
    //                    <div class="sc-quantity">
    //                        1X <span class="sc-price"> $1,124</span>
    //                    </div>
    //                    <a href="javascript:void(0);" class="sc-produc-remove">
    //                        <img src="~/assets/images/index1/svg/cut.svg" alt="icon">
    //                    </a>
    //                </li>
    //                <li>
    //                    <div class="sc-productwrap">
    //                        <a href="product_details.html" class="sc-product-thumb">
    //                            <img src="~/assets/images/index1/shopcart04.jpg" alt="Product" class="img-fluid">
    //                        </a>
    //                        <div class="sc-product-details">
    //                            <a href="product_details.html" class="sc-product-ttl">Black Bomber Jacket</a>
    //                            <p class="sc-product-sz">Size : Medium</p>
    //                        </div>
    //                    </div>
    //                    <div class="sc-quantity">
    //                        1X <span class="sc-price"> $2,451</span>
    //                    </div>
    //                    <a href="javascript:void(0);" class="sc-produc-remove">
    //                        <img src="~/assets/images/index1/svg/cut.svg" alt="icon">
    //                    </a>
    //                </li>
    //                <li>
    //                    <div class="sc-productwrap">
    //                        <a href="product_details.html" class="sc-product-thumb">
    //                            <img src="~/assets/images/index1/shopcart05.jpg" alt="Product" class="img-fluid">
    //                        </a>
    //                        <div class="sc-product-details">
    //                            <a href="product_details.html" class="sc-product-ttl">Full Sleeve Balloon Jacket</a>
    //                            <p class="sc-product-sz">Size : Medium</p>
    //                        </div>
    //                    </div>
    //                    <div class="sc-quantity">
    //                        1X <span class="sc-price"> $320</span>
    //                    </div>
    //                    <a href="javascript:void(0);" class="sc-produc-remove">
    //                        <img src="~/assets/images/index1/svg/cut.svg" alt="icon">
    //                    </a>
    //                </li>