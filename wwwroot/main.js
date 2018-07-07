var source = new EventSource('/api/values/stream');
const contentElem = document.getElementById("content");

source.onmessage = function (e) {
    contentElem.innerHTML += "<p>"+e.data+"</p>"
};

source.onopen = function(e) {
    console.log('Opened');
};

source.onerror = function(e) {
    console.log('Error: '+e.data);
};