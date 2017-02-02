var EditTaskController = function (editTaskService) {

    var taskId = $("#Task_Id");

    var done = function () {
        location.reload();
    }

    var fail = function () {
        alert("Something failed!");
    }

    var showForm = function () {
        var inAnimateClass = "animated bounceIn";
        $(".js-sidebar-content")
            .toggleClass("hidden")
            .toggleClass(inAnimateClass);
        $(".js-edit-task-content")
            .toggleClass(inAnimateClass)
            .toggleClass("hidden");
    }

    var fillForm = function (taskBox) {
        $(".js-edit-task-name")
            .val(taskBox.find(".task-name")
            .text()
            .trim());
        $(".js-edit-dropdown-projects")
            .val(taskBox.attr("data-project-id"));
        $(".js-edit-dropdown-tags")
            .val(taskBox.attr("data-tag-id"));
        $(".js-edit-dropdown-priority")
            .val(taskBox.attr("data-priority"));
        $(".js-edit-date")
            .val(taskBox.attr("data-date"));
        $(".js-edit-time")
            .val(taskBox.attr("data-time"));
        taskId.val(taskBox.attr("data-task-id"));
    }

    var openForm = function (taskBox) {
        showForm();
        fillForm(taskBox);
    }

    var editTask = function () {
        editTaskService.edit(taskId.val(), done, fail);
    }

    var deleteTask = function () {
        editTaskService.delet(taskId.val(), done, fail);
    }

    var init = function () {
        $(".js-task-box").on("click", function () { openForm($(this)) });
        $(".js-edit-task").on("click", editTask);
        $(".js-delete-task").on("click", deleteTask);
    }

    return {
        init: init
    }
}(EditTaskService);