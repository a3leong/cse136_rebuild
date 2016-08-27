function ScheduleListViewModel() {
    this.Load = function () {
        var scheduleListModelObj = new ScheduleListModel();

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        scheduleListModelObj.Load(function (scheduleListData) {

            // courseList - presentation layer model retrieved from /schedule/GetscheduleList route.
            // scheduleListViewModel - view model for the html content
            var scheduleListViewModel = new Array();

            // DTO from the JSON model to the view model. In this case, scheduleListViewModel doesn't need the "id" attribute
            for (var i = 0; i < scheduleListData.length; i++) {
                scheduleListViewModel[i] = {
                    Year: scheduleListData[i].Year,
                    Quarter: scheduleListData[i].Quarter,
                    Session: scheduleListData[i].Session,
                    Course: scheduleListData[i].Course,
                    Instructor: scheduleListData[i].Instructor,
                    Day: scheduleListData[i].Day,
                    Time: scheduleListData[i].Time
                };
            }

            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: scheduleListViewModel }, document.getElementById("divScheduleListEdit"));
        });
    };
}
