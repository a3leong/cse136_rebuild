function ScheduleListModel() {

    this.Load = function (callback) {
  /**      $.ajax({
            url: "http://localhost:9393/Api/Schedule/GetScheduleList",
            data: "",
            dataType: "json",
            success: function (courseListData) {
                callback(courseListData);
            },
            error: function () {
                alert('Error while loading course list.  Is your service layer running?');
            }
        });  We do this for part 5 **/
        var scheduleList = [];
        scheduleList.push({
            Year: "2011",
            Quarter: "Spring",
            Session: "A",
            Course: "Introduction to Java",
            Instructor: "John Smith",
            Day: "MW",
            Time: "9am-12pm"
        });
        scheduleList.push({
            Year: "2012",
            Quarter: "Winter",
            Session: "B",
            Course: "Data Structures",
            Instructor: "Some Instructor",
            Day: "TuThurs",
            Time: "10am-11:50pm"
        });
        callback(scheduleList);
    };
}
