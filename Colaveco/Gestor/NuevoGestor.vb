Public Class NuevoGestor
    Inherits Conectoras.ConexionMySQLGestor


    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoGestor = CType(o, dNuevoGestor)


        Dim sql As String = "INSERT INTO informe (InformeId, ClienteId, InformeSubTipoId, InformeObservaciones, InformeNumMuestras, MuestraId, InformeSinSol, InformeSinConservante, InformeTemperatura, InformeDerramadas, InformeDesvio, InformeFechaIngreso, InformeFechaFinalizado, InformeEstadoId) VALUES (" & obj.ID & ", " & obj.IDPRODUCTOR & "," & obj.IDSUBINFORME & ", '" & obj.OBSERVACIONES & "'," & obj.NMUESTRAS & "," & obj.IDMUESTRA & "," & obj.SINCOLICITUD & "," & obj.SINCONSERVANTE & ", " & obj.TEMPERATURA & ", " & obj.DERRAMADAS & ", " & obj.DESVIOAUTORIZADO & ", '" & obj.FECHAINGRESO & "','" & obj.FECHAENVIO & "', 1)" ')"
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function modificarEstado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoGestor = CType(o, dNuevoGestor)
        Dim sql As String = "UPDATE Informe SET InformeEstadoId =" & obj.SOLICITUDESTADOID & " WHERE InformeId = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function
End Class
