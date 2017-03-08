var NotificationsService = function () {

    var create = function(fail) {
        $.post("/api/notifications/createoverduenotifications")
            .done()
            .fail(fail);
    }

    var makeAsRead = function(done, fail) {
        $.post("/api/notifications/makeasread")
            .done(done)
            .fail(fail);
    }

    return {
        create: create,
        makeAsRead: makeAsRead,
    }
}()