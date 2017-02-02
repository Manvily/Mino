var AddTaskController = function (addTaskService) {

    var showModal = function () {
        $("#createModal").modal("show");
    }

    var getTaskName = function () {
        return $(".js-task-name").val();
    }

    var done = function () {
        $("#createModal").modal("hide");
        location.reload();
    }

    var fail = function () {
        alert("Something failed!");
    }

    var createTask = function () {
        $(".js-task-create").on("click", addTaskService.create(getTaskName(), done, fail));
    }

    var init = function () {
        $(".js-show-modal").on("click", showModal);
        $(".js-task-create").on("click", createTask);
    }

    return {
        init: init
    }
}(AddTaskService);