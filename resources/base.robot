* Settings *
Documentation       Tudo deve começar por aqui

Library         SikuliLibrary

Resource        actions/pdv.robot

* Keywords *
Carrega os Elementos do App
    Add Image Path      ${EXECDIR}\\resources\\elements

Inicia Sessão
    Carrega os Elementos do App
    Click           icone-app.png

Encerrar Sessão
    Stop Remote Server

Finaliza Teste
    Capture Screen
    Close Application       BugBakery