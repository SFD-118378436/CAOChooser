// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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