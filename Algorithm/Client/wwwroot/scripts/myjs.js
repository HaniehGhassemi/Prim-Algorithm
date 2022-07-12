function getOffset(el) {
    var rect = el.getBoundingClientRect();
    return {
        left: rect.left + window.pageXOffset,
        top: rect.top + window.pageYOffset,
        width: rect.width || el.offsetWidth,
        height: rect.height || el.offsetHeight
    };
}

function connect(div1, div2, color, thickness,cost) { // draw a line connecting elements
    var divOne = document.getElementById(div1);
    var divTwo = document.getElementById(div2);

    var off1 = getOffset(divOne);
    var off2 = getOffset(divTwo);
    // bottom right
    var x1 = off1.left + off1.width / 2;
    var y1 = off1.top + off1.height / 2;
    // top right
    var x2 = off2.left + off2.width / 2;
    var y2 = off2.top + off2.width / 2;
    // distance
    var length = Math.sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1))) - 50;
    // center
    var cx = ((x1 + x2) / 2) - (length / 2);
    var cy = ((y1 + y2) / 2) - (thickness / 2);
    // angle
    var angle = Math.atan2((y1 - y2), (x1 - x2)) * (180 / Math.PI);
    // make hr
    var htmlLine = "<div style='text-align:center;color:yellow;padding:0px; margin:0px; height:" + thickness + "px; background-color:" + color + "; line-height:1px; position:absolute; left:" + cx + "px; top:" + cy + "px; width:" + length + "px; -moz-transform:rotate(" + angle + "deg); -webkit-transform:rotate(" + angle + "deg); -o-transform:rotate(" + angle + "deg); -ms-transform:rotate(" + angle + "deg); transform:rotate(" + angle + "deg);' >"+"<span style='background-color:red;padding:10px;'>" + cost+"</span>"+"</div>";
    //
    // alert(htmlLine);

    document.body.innerHTML += htmlLine;
    
}



