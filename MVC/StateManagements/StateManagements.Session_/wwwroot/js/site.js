$(() => {
    $('.cart').on('click', (e) => {
        let id = $(e.currentTarget).data('id');
        $.ajax({
            url: `/cart/add/${id}`,
            method: 'post',
            success: () => GetAll(),
            error: (err) => { console.log(err) }
        });
    });


    function GetAll() {
        $.getJSON('/cart/getall', (data) => {

            let templates = [];

            $.each(data, (key, value) => {
                let template = `<li>
                                      <div class="sc-productwrap">
                                          <a href="product_details.html" class="sc-product-thumb">
                                              <img src="${value.cartImage}" alt="Product" class="img-fluid">
                                          </a>
                                          <div class="sc-product-details">
                                              <a href="product_details.html" class="sc-product-ttl">${value.name}</a>
                                              <p class="sc-product-sz">Size : Medium</p>
                                          </div>
                                      </div>
                                      <div class="sc-quantity">
                                          1X <span class="sc-price"> $${value.price}</span>
                                      </div>
                                      <a  href="javascript:void(0);" class="sc-produc-remove">
                                          <img src="assets/images/index1/svg/cut.svg" alt="icon">
                                      </a>
                                  </li >`;

                templates.push(template);
            })

            $('.sb-cartbox-list').html(templates.join('</br>'));

        })
    }

    GetAll();

    

    //$('.sc-produc-remove').on('click', (e) => {

    //    alert('safsd')
    //    let id = $(e.currentTarget).data('id');
    //    $.ajax({
    //        url: `/cart/remove/${id}`,
    //        method: 'post',
    //        success: (data) => alert(data),
    //        error: (err) => { console.log(err) }
    //    });
    //});

    $('.increase').on('click', (e) => {
        let curentItem = e.currentTarget;
    });

    $('.decrease').on('click', (e) => {
        let curentItem = e.currentTarget;
    });
}) 