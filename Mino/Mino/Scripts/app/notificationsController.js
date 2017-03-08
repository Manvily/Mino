var NotificationsController = function (notificationsService) {

    var done = function () {
        console.log("Succes");
    }

    var fail = function () {
        alert("Something failed!");
    }

    var setNotificationsCount = function (length) {
        $(".js-notifications-count")
            .text(length)
            .removeClass("hide")
            .addClass("animated bounceInDown");
    }

    var makeAsRead = function () {
        notificationsService.makeAsRead(done, fail);
        $(".js-notifications-count").addClass("hidden");
    }

    var showNotifications = function () {
        $.getJSON("/api/notifications/getnewnotifications",
             function (notifications) {

                 if (notifications.length == 0) {
                     return;
                 }

                 setNotificationsCount(notifications.length);
                 $(".notifications").popover({
                     html: true,
                     title: "Notifications",
                     content: function () {
                         var compiled = _.template($("#notifications-template").html());
                         return compiled({ notifications: notifications });
                     },
                     placement: "bottom",
                     template:
                         '<div class="popover popover-notifications" role="tooltip"><div class="arrow"></div><h3 class="popover-title"></h3><div class="popover-content"></div></div>'
                 }).on("shown.bs.popover",
                     function () {
                         makeAsRead();
                     });
             });
    }

    var init = function () {
        notificationsService.create(fail);
        showNotifications();
    }

    return {
        init: init
    }
}(NotificationsService)