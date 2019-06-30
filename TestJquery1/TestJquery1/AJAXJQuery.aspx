<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AJAXJQuery.aspx.cs" Inherits="TestJquery1.AJAXJQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AJAX JQuery</title>
    <script type="text/javascript" src="Scripts/jquery-1.12.1.min.js"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            /***************************************
            Llamado AJAX Service Method WebForm
            ****************************************/
            $("#DivPreguntas").html("");
            $.ajax({
                //Permite definir el tipo de llamado GET o POST siendo POST el mejor
                type: "POST",
                //Define la ruta al WebMethod existente en el code-behind
                url: "AJAXJQuery.aspx/GetPreguntasJson",
                //Permite pasar parametro en formato JSON (string) Hay Utilities como JSON2, 
                //que permite serializar falcilmente a este fomato
                data: {},
                //Define el content type que viajara en los bloques HTTP
                contentType: "application/json; chartset:utf-8",
                //Define el tipo de datos que se va a manejar xml, json
                dataType: "json",
                //Esta sección permite definir una función anónima, la cual se encargará de 
                //recibir los resultados provenientes del servidor, 
                //en este caso serializados en formato JSON
                success:
                    function (result) {
                        var obj= $.parseJSON(result.d)
                        if (obj.length > 0) {
                            var table = $("<table></table>");
                            table.append($("<tr style='background:#EBEBEB;'></tr>").append("<td>Código</td><td>Nombre</td><td>Respuesta</td>"))
                            for (var i = 0; i < obj.length; i++) {
                                table.append($("<tr></tr>").append("<td>" + obj[i].Id + "</td><td>¿" + obj[i].Name + "?</td><td><input type='text' id='txtResp" + obj[i].Id + "'/></td>"));
                            }
                                $("#DivPreguntas").append(table);
                            }
                        },
                    //Esta función permite definir una función anónima que 
                    //se encargara de gestionar los posibles erroes.
                    error: 
                    function (XmlHttpError, error, description) {
                        $("#DivPreguntas").html(XmlHttpError.responseText);
                    },
                    async: true
                });

            /*****************************************************
            Llamado AJAX Servicio ASMX
            Es importante descomentar :  [System.Web.Script.Services.ScriptService]
            En la clase del servicio, pues esto habilita la 
            funcionalidad  AJAX.
            ******************************************************/
            $("#btnRespuestas").click(function () {
                $.ajax({
                    //Permite definir el tipo de llamado GET o POST siendo POST el mejor
                    type: "POST", 
                    //Define la ruta al WebMethod existente en el Servicio ASMX
                    url: "Service/WebServicePerson.asmx/Respuestas", 
                    //Permite pasar parametro en formato JSON (string) Hay Utilities como JSON2, 
                    //que permite serializar falcilmente a este fomato
                    data: '{ "Respuestas":"' + $("#txtResp1").val() + ", " + $("#txtResp2").val() + ", " + $("#txtResp3").val()+ ", " + $("#txtResp4").val()+ ", " + $("#txtResp5").val() +'" }',
                    //Define el content type que viajara en los bloques HTTP
                    contentType: "application/json; chartset:utf-8",
                    //Define el tipo de datos que se va a manejar xml, json
                    dataType: "json",
                    //Esta sección permite definir una función anónima, la cual se encargará de 
                    //recibir los resultados provenientes del servidor, en este caso 
                    //serializados en formato JSON
                    success: 
                        function (result) {
                            if (result.d) {
                                alert(result.d);
                            }
                        },
                    //Esta función permite definir una función anónima que se 
                    //encargara de gestionar los posibles erroes.
                    error: 
                    function (XmlHttpError, error, description) {
                        $("#DivPreguntas").html(XmlHttpError.responseText);
                    },
                    async: true
                });
            });


           
        });
    </script>
</head>

<body>
    <form id="form1" runat="server">
    Encuesta:<br />
    <br />
    <div id="DivPreguntas">
    </div>
    <div id="DivASMXHelloWorld">
    </div>
    <br />
    <div>
    <input id="btnRespuestas" type="button" value="Revisar Respuestas"/>
    </div>
    </form>
</body>
</html>
