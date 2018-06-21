// JavaScript source code
// Solving: JQuery

$("#wondering").change(function () {
    let val = $("#wondering").val() + 'px';
    $("#mouth").css('width', val);
    $("#mouth").css('height', val);
});

$('input[name=eyes]').click(function () {
    let val = $('input[name=eyes]:checked').val();
    $(".eye").css('background', val);

});

$("#lh").change(function () {
    let val = 'rotate(' + $("#lh").val() + 'deg)';
    $("#left-arm").css('transform', val);
});

$("#rh").change(function () {
    let val = 'rotate(-' + $("#rh").val() + 'deg)';
    $("#right-arm").css('transform', val);
});

$("#lf").change(function () {
    let val = 'rotate(' + $("#lf").val() + 'deg)';
    $("#left-leg").css('transform', val);
});

$("#rf").change(function () {
    let val = 'rotate(-' + $("#rf").val() + 'deg)';
    $("#right-leg").css('transform', val);
});

$("#clothes").change(function () {
    let val = $("#clothes").val();
    switch (val) {
        case 'white':
            $("#body").css('background', val);
        case 'yellow':
            $("#body").css('background', val);
        case 'cyan':
            $("#body").css('background', val);
        case 'red':
            $("#body").css('background', val);
    }
});

$("#socks").change(function () {
    let val = $("#socks").prop("checked");
    if (val) {
        $(".socks").show();
    }
    else {
        $(".socks").hide();
    }
});

$("#reset").click(function () {
    location.reload();
})