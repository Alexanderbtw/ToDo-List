$(document).ready(function () {
    $(".del-btn").click(function () {
        var task_id = Number($(this).parent().parent().find('.task-id').text());
        $.ajax({
            url: "/Task/DelTask",
            type: "DELETE",
            dataType: "json",
            data: { id: task_id }
        });
        $(this).parent().parent().remove();
    });

    $(".hide-btn").click(function () {
        var desc = $(this).parent().parent().find('.for-anim');
        if (desc.is(':visible')) {
            desc.slideUp(500);
            $(this).removeClass('rotate-min-90').addClass('rotate-90');
        }
        else {
            desc.slideDown(500);
            $(this).removeClass('rotate-90').addClass('rotate-min-90');
        }
    });
});