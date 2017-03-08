var TasksController = function (tasksService) {

    var taskId = $("#Task_Id");

    var doneEdit = function () {
        location.reload();
    }

    var doneFinish = function (task) {
        var li = task.closest("li");
        li.toggleClass("animated fadeOut");
        setTimeout(function () {
            li.toggleClass("hidden");
        },700);
    }

    var doneAdd = function () {
        $("#createModal").modal("hide");
        location.reload();
    }

    var fail = function () {
        alert("Something failed!");
    }

    var getDoneTaskId = function (task) {
        return task.closest(".task-box").attr("data-task-id");
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
        tasksService.edit(taskId.val(), doneEdit, fail);
    }

    var deleteTask = function () {
        tasksService.delet(taskId.val(), doneEdit, fail);
    }

    var changeGlyphicon = function (task) {
        task.toggleClass("glyphicon-unchecked").toggleClass("glyphicon-check");
    }

    var finishTask = function (task) {
        tasksService.finish(getDoneTaskId(task), doneFinish(task), fail);
    }

    var showCreateModal = function () {
        $("#createModal").modal("show");
    }

    var getNewTaskName = function () {
        return $(".js-task-name").val();
    }

    var createTask = function () {
        $(".js-task-create").on("click", tasksService.create(getNewTaskName(), doneAdd, fail));
    }

    var init = function () {
        $(".js-task-reference").on("click", function (e) { e.stopPropagation(); });
        $(".js-task-box").on("click", function () { openForm($(this)) });
        $(".js-edit-task").on("click", editTask);
        $(".js-delete-task").on("click", deleteTask);
        $(".js-toggle-task").hover(function () { changeGlyphicon($(this)) });
        $(".js-toggle-task").on("click", function (e) {
            finishTask($(this));
            e.stopPropagation();
        });
        $(".js-show-modal").on("click", showCreateModal);
        $(".js-task-create").on("click", createTask);
    }

    return {
        init: init
    }
}(TasksService);