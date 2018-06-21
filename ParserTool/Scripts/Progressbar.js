$(function () {

    $(".progress-bar").each(function () {
        bar = $(this).attr('value');

        var scaling = 0;

        var divider = (bar / Math.pow(bar, 0.760)) * 235.71;

        if (bar > 0 && bar < 10000) {
            scaling = bar / divider;
            $(this).css("background-color", "#f63a0f");
        }

        else if (bar > 10000 && bar < 50000) {
            scaling = bar / divider;
            $(this).css("background-color", "#f27011");
        }

        else if (bar > 50000 && bar < 100000) {
            scaling = bar / divider;
            $(this).css("background-color", "#f2b01e");
        }

        else if (bar > 100000 && bar < 500000) {
            scaling = bar / divider;
            $(this).css("background-color", "#f2d31b");
        }

        else if (bar > 500000) {
            scaling = bar / divider;
            $(this).css("background-color", "#86e01e");
        }

        $(this).animate({ width: scaling + '%' }, 'slow');

    });
});