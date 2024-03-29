﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//Code to subtract values
function subtractValues(s) {

    creativevalue = creativevalue - s.creative;
    interpersonalvalue = interpersonalvalue - s.interpersonal;
    analyticalvalue = analyticalvalue - s.analytical;
    problemsolvingvalue = problemsolvingvalue - s.problemsolving;
}

function addValues(c) {
    //Code to add values
    creativevalue = creativevalue + c.creative;
    interpersonalvalue = interpersonalvalue + c.interpersonal;
    analyticalvalue = analyticalvalue + c.analytical;
    problemsolvingvalue = problemsolvingvalue + c.problemsolving;
}

function valueAssign() {
    document.getElementById("txtCreative").value = creativevalue;
    document.getElementById("txtProblemSolving").value = problemsolvingvalue;
    document.getElementById("txtAnalytical").value = analyticalvalue;
    document.getElementById("txtInterpersonal").value = interpersonalvalue;
}


//https://stackoverflow.com/questions/47582330/javascript-checkbox-sum/47582361
function Realistic() {
    var rvalues = document.getElementsByName("Realistic");
    for (var i = 0; i < rvalues.length; i++) {
        if (rvalues[i].checked) {
            rtotal += parseInt(rvalues[i].value);
        }
    } 
}

function Investigative() {
    var ivalues = document.getElementsByName("Investigative");    
    for (var i = 0; i < ivalues.length; i++) {
        if (ivalues[i].checked) {
            itotal += parseInt(ivalues[i].value);
        }
    }
}

function Artistic() {
    var avalues = document.getElementsByName("Artistic");
    for (var i = 0; i < avalues.length; i++) {
        if (avalues[i].checked) {
            atotal += parseInt(avalues[i].value);
        }
    }
}

function Social() {
    var svalues = document.getElementsByName("Social"); 
    for (var i = 0; i < svalues.length; i++) {
        if (svalues[i].checked) {
            stotal += parseInt(svalues[i].value);
        }
    }
}

function Enterprising() {
    var evalues = document.getElementsByName("Enterprising");
    for (var i = 0; i < evalues.length; i++) {
        if (evalues[i].checked) {
            etotal += parseInt(evalues[i].value);
        }
    }
}

function Conventional() {
    var cvalues = document.getElementsByName("Conventional");
    for (var i = 0; i < cvalues.length; i++) {
        if (cvalues[i].checked) {
            ctotal += parseInt(cvalues[i].value);
        }
    }
}

function Update() {
    Realistic();
    Investigative();
    Artistic();
    Social();
    Enterprising();
    Conventional();


    document.getElementById("R").value = rtotal;
    document.getElementById("I").value = itotal;
    document.getElementById("A").value = atotal;
    document.getElementById("S").value = stotal;
    document.getElementById("E").value = etotal;
    document.getElementById("C").value = ctotal;
}


//https://dev.to/jamiemcmanus/creating-a-live-search-with-ajax-net-9od
//https://www.aspsnippets.com/Articles/ASPNet-MVC-Implement-Search-functionality-using-jQuery-AJAX.aspx
//Search bar function dynamically ajax 
function LiveSearch() {

    //Get the input value
    let value = $.trim($("#txtsearch").val());
    let college = $.trim($("#tlidrop").val());
    let level = $.trim($("#lvldrop").val());


    $.ajax({
        type: "Get",
        url: "/Home/GetSearchingData?searchString="+ value + "&college=" + college + "&level=" + level,
        
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (courses) {
            var table = $("#tblcourse");
            table.find("tr:not(:first)").remove();
            $.each(courses, function (i, course) {
                var table = $("#tblcourse");
                var row = table[0].insertRow(-1);
                var link = "<a href='/Home/ViewIndividualCourse?CourseID=" + course.courseID +"'>" + course.courseID + "</a>"


                $(row).append("<td />");
                $(row).find("td").eq(0).html(link);
                $(row).append("<td />");
                $(row).find("td").eq(1).html(course.courseName);
                $(row).append("<td />");
                $(row).find("td").eq(2).html(course.level);
                $(row).append("<td />");
                $(row).find("td").eq(3).html(course.thirdLevelInstitute);
            });
        }
    });
}



