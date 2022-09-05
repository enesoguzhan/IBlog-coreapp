const infoMessageUrl = '';

function showInfoToast(info, href) {
    addInfoMessage(info, href);
}


function addInfoMessage(info, href) {
    var pDatas = {
        info: info,
        href: href
    }

    $.ajax({
        type: "POST",
        url: infoMessageUrl + "/AddInfoMessage",
        data: $.toJSON(pDatas),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (data) {
            var result = jQuery.parseJSON(data.d);
            if (result.success) {
                if (href == "back")
                    location.href = document.referrer;
                else if (href == "refresh")
                    location.reload();
                else
                    location.href = href;
            }
            else {
                showErrorModal(result.errorMessages, result.errorCode);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    });
}