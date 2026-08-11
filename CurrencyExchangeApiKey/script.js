const amount=document.getElementById("amount");
const fromCurrency=document.getElementById("fromCurrency");
const toCurrency=document.getElementById("toCurrency");
const convertBtn=document.getElementById("convertBtn");
const swap=document.getElementById("swap");
const resultValue=document.getElementById("resultValue");
const rate=document.getElementById("rate");
const status=document.getElementById("status");

async function convertCurrency(){
const value=parseFloat(amount.value);
const from=fromCurrency.value;
const to=toCurrency.value;

if(!value||value<=0){
resultValue.textContent="Enter a valid amount";
rate.textContent="";
status.textContent="";
return;
}

status.textContent="Loading...";
convertBtn.disabled=true;

try{
const response=await fetch("rates.json");
if(!response.ok)throw new Error("Currency data could not be loaded");
const data=await response.json();
const fromRate=data.rates[from];
const toRate=data.rates[to];
const exchangeRate=toRate/fromRate;
const converted=value*exchangeRate;
resultValue.textContent=`${converted.toLocaleString(undefined,{maximumFractionDigits:2})} ${to}`;
rate.textContent=`1 ${from} = ${exchangeRate.toFixed(4)} ${to}`;
status.textContent="Conversion successful";
}catch(error){
resultValue.textContent="Error";
rate.textContent=error.message;
status.textContent="";
}finally{
convertBtn.disabled=false;
}
}

swap.addEventListener("click",()=>{
const oldFrom=fromCurrency.value;
fromCurrency.value=toCurrency.value;
toCurrency.value=oldFrom;
convertCurrency();
});

convertBtn.addEventListener("click",convertCurrency);

amount.addEventListener("keypress",e=>{
if(e.key==="Enter")convertCurrency();
});

convertCurrency();