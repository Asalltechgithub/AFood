function TornaBotaoAtualizarQuantidadeVisivel(id, visible) {

    const atualizaQuantidadeButton = document.querySelector("button[data-itemId='" + id + "']");

    if (visible == true) {
        atualizaQuantidadeButton.style.display = "inline-block";
    }
    else {
        atualizaQuantidadeButton.style.display = "none";
    }
}

$("#tabs-demo").mdtabs({

  // height of the indicator

  height: 3,
   
  color: "#FD0",
  
  duration: 200,
   

  onClick: null,
    
  onIndicaterMoved: null,
   
});
