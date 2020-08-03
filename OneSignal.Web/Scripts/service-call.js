
function CallPost(url, data, callback) {
    $.ajax({
        url: url,
        dataType: 'json',
        data: data,
        type: 'POST',
        success: function (result) {
            if (result !== null && result !== undefined) {
                if (!result.isSuccess) {
                    // showToast(result.Message, "Error");
                }
                //else {
                //    showSuccessToastr(result.Message);
                //}
            }
            callback(result);
        },
        error: function (xhr) {
        }
    });
}
function CallGet(url, callback) {
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'GET',
        success: function (result) {
            if (result !== null && result !== undefined) {
                if (!result.isSuccess) {
                    //showErrorToastr(result.Message, 'Error');
                    // showToast(result.Message, "Error");
                }
            }
            callback(result);
        },
        error: function (xhr) {
        }
    });
}
