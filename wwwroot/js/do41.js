$(document).ready(function(){//Всё так же только убран скрипт на вторую прогрмамму 
var ad= $(document).width();
	
var a=false;
var start = 1;
var timer;
var timer_o;
var timer_d;
var timer_d1;
var doj=1;
var start_o=0
var vkl=false;
var fps=0.2;


document.querySelector('#h4').style.display = 'none';
let elem = document.querySelector('.tam');
console.log(elem.offsetHeight);
step();//присваевание картинки ацкия huawei скрытость
function step() {setTimeout(function ad(){//Интервальная функция будет выполняться всегда
    requestAnimationFrame(step);// чтобы анимация не нагружала систему когда страница свёрнута
//Чередование рекламы на странице
	if (a==false){//Афоны будут исчезать, а хуавеи будут появляться
		
		 opt();
		 function opt(){document.querySelector('#h3').style.opacity=start;//прозрачность афонов падает 
			
			start=start-0.05;
			
			if(start>=0){
			timer=setTimeout(opt,50);}else{endi();
				document.querySelector('#h3').style.display = 'none';start=1;opt_o();}

			}
			opt();

		 function opt_o(){//Айфоны исчезли и появились хуавеи
		 	document.querySelector('#h3').style.opacity=start;
		 	document.querySelector('#h4').style.opacity=start_o;
		 	document.querySelector('#h4').style.display = 'initial';


			start_o=start_o+0.05;
			
			if(start_o<=1){
			timer_o=setTimeout(opt_o,50);}else{endid();start_o=0;}
			}	    
	}
	    function endi(){clearTimeout(timer);}

	    function endid(){clearTimeout(timer_o);}
	    
	

    
	if (a==true){//хуавеи исчезают
		opt_d();
		 function opt_d(){document.querySelector('#h4').style.opacity=start;
			
			start=start-0.05;
			
			if(start>=0){
			timer_d=setTimeout(opt_d,50);}else{endi_d();document.querySelector('#h4').style.display = 'none';start=1;opt_d1();}
			}	

		 function opt_d1(){//айфоны появляються 
		 	document.querySelector('#h4').style.opacity=start;
		 	document.querySelector('#h3').style.opacity=start_o;
		 	document.querySelector('#h3').style.display = 'initial';
			start_o=start_o+0.05;
			
			if(start_o<=1){
			timer_o=setTimeout(opt_d1,50);}else{endid_d1();start_o=0;}
			}
		function endi_d(){clearTimeout(timer_d);}

	    function endid_d1(){clearTimeout(timer_d1);}
        
	}
	if (a==false) {a=true;}else{a=false;}
		

 }, 1000/fps);}
})