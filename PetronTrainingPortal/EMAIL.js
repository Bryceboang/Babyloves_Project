$(function () {
    $('.btnSendEmail5').click(function (event) {
        var email = 'escruz@petron.com';
        var subject = 'STATUS AUTOEMAIL';
        var emailBody = 'SAMPLE BODY TEXT HERE';
        //var emailBodyGrid = gridView;
        window.location = 'mailto:' + email + '?subject=' + subject + '&body=' + emailBody + emailBodyGrid;
    });
});