var color = document.querySelector('#color')
var eraser = document.querySelector('#eraser')
var decrease = document.querySelector('#decrease')
var sizeEL = document.querySelector('#size')
var increase = document.querySelector('#increase')
var save = document.querySelector('#save')
var clear = document.querySelector('#clear')
var canvas = document.querySelector('canvas')

var ctx = canvas.getContext('2d')
var colorPain = '#000000'
var size = 5
sizeEL.innerText = size

var post1 = {
    x: 0,
    y: 0
}
var post2 = {
    x: 0,
    y: 0
}
var isDrawing = false
document.addEventListener('mousedown', function(e) {
    post1 = {
        x: e.offsetX,
        y: e.offsetY
    }
    isDrawing = true
})
document.addEventListener('mousemove', function(e) {
    if (isDrawing) {
        post2 = {
            x: e.offsetX,
            y: e.offsetY
        }

        //ve fill
        ctx.beginPath();
        ctx.arc(post1.x, post1.y, size, 0, 2 * Math.PI);
        ctx.fillStyle = colorPain;
        ctx.fill();

        //Ve outline
        ctx.beginPath();
        ctx.moveTo(post1.x, post1.y);
        ctx.lineTo(post2.x, post2.y);
        ctx.strokeStyle = colorPain;
        ctx.lineWidth = size * 2;
        ctx.stroke();

        post1.x = post2.x;
        post1.y = post2.y
    }
})
document.addEventListener("mouseup", function(e) {
    isDrawing = false
})
color.addEventListener("change", function(e) {
    colorPain = e.target.value
})
decrease.addEventListener('click', function() {
    size -= 5
    size = size > 5 ? size : 5
    sizeEL.innerText = size
})
increase.addEventListener('click', function() {
    size += 5
    size = size < 35 ? size : 35
    sizeEL.innerText = size
})
eraser.addEventListener('click', function() {
    colorPain = '#ffffff'
})
clear.addEventListener('click', function() {
    var canvasStat = canvas.getClientRects()[0]
    ctx.clearRect(0, 0, canvasStat.width, canvasStat.height)
})
save.addEventListener('click', function() {
    var output = canvas.toDataURL('image/png');
    save.setAttribute('href', output)
})