function MajorListModel() {

    this.Load = function (callback) {
  /**      $.ajax({
            url: "http://localhost:9393/Api/Major/GetMajorList",
            data: "",
            dataType: "json",
            success: function (courseListData) {
                callback(courseListData);
            },
            error: function () {
                alert('Error while loading course list.  Is your service layer running?');
            }
        });  We do this for part 5 **/
        var MajorList = [];
        MajorList.push({
            FullName: "Computer Science",
            Description: "Learn how to hello world."
        });
        MajorList.push({
            FullName: "Computer Science2",
            Description: "Learn how search Stack Overflow."
        });
        callback(MajorList);
    };
}
