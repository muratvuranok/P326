$(() => {

    let connection = new signalR.HubConnectionBuilder().withUrl("/signalRServer").build()
    connection.start();

    connection.on("getCategories", function () {
        loadProducts();
    });

    loadProducts();
    function loadProducts() {

        var tr = '';
        $.ajax({
            url: '/categories/getCategories',
            method: 'GET',
            success: (result) => {

                console.log(result)
                $.each(result, (key, value) => {
                    tr = tr + `<tr>   
                                   <td> ${value.id} </td>
                                   <td> ${value.name} </td>
                                   <td> ${value.description} </td> 
                               </tr>`;
                })
                $('#categories').html(tr);
            },
            error: (result) => {
                console.log(result);
            }
        })
    }
});