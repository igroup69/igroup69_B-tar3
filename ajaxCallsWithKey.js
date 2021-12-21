function ajaxCall2(method, api, data, successCB, errorCB) {
    $.ajax({
        type: method,
        url: api,
        data: data,
        cache: false,
        headers: {
            'x-rapidapi-key': 'cb67dc7c93mshb522ea36f57e0c3p110632jsna1aaeda4875d',   // replace it with your own key
        },
        contentType: "application/json",
        dataType: "json",
        success: successCB,
        error: errorCB
    });
}