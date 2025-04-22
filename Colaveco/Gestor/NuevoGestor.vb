Public Class NuevoGestor
    Inherits Conectoras.ConexionMySQLGestor


    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoGestor = CType(o, dNuevoGestor)
        Dim lista As New ArrayList()

        ' Verificar si el InformeId ya existe en la base de datos
        Dim sqlVerificar As String = "SELECT COUNT(*) FROM informe WHERE InformeId = " & obj.ID
        Dim existe As Integer = EjecutarEscalar(sqlVerificar)

        If existe > 0 Then
            ' Si el registro existe, se hace un UPDATE
            Dim sqlUpdate As String = "UPDATE informe SET " &
                "ClienteId = " & obj.IDPRODUCTOR & ", " &
                "InformeSubTipoId = " & obj.IDSUBINFORME & ", " &
                "InformeObservaciones = '" & obj.OBSERVACIONES & "', " &
                "InformeNumMuestras = " & obj.NMUESTRAS & ", " &
                "MuestraId = " & obj.IDMUESTRA & ", " &
                "InformeSinSol = " & obj.SINCOLICITUD & ", " &
                "InformeSinConservante = " & obj.SINCONSERVANTE & ", " &
                "InformeTemperatura = " & obj.TEMPERATURA & ", " &
                "InformeDerramadas = " & obj.DERRAMADAS & ", " &
                "InformeDesvio = " & obj.DESVIOAUTORIZADO & ", " &
                "InformeFechaIngreso = '" & obj.FECHAINGRESO & "', " &
                "InformeFechaFinalizado = '" & obj.FECHAENVIO & "', " &
                "InformeEstadoId = 1 " &
                "WHERE InformeId = " & obj.ID
            lista.Add(sqlUpdate)
        Else
            ' Si el registro no existe, se hace un INSERT
            Dim sqlInsert As String = "INSERT INTO informe (InformeId, ClienteId, InformeSubTipoId, InformeObservaciones, InformeNumMuestras, MuestraId, InformeSinSol, InformeSinConservante, InformeTemperatura, InformeDerramadas, InformeDesvio, InformeFechaIngreso, InformeFechaFinalizado, InformeEstadoId) " &
                                      "VALUES (" & obj.ID & ", " & obj.IDPRODUCTOR & "," & obj.IDSUBINFORME & ", '" & obj.OBSERVACIONES & "'," & obj.NMUESTRAS & "," & obj.IDMUESTRA & "," & obj.SINCOLICITUD & "," & obj.SINCONSERVANTE & ", " & obj.TEMPERATURA & ", " & obj.DERRAMADAS & ", " & obj.DESVIOAUTORIZADO & ", '" & obj.FECHAINGRESO & "','" & obj.FECHAENVIO & "', 1)"
            lista.Add(sqlInsert)
        End If

        ' Ejecutar la transacción (INSERT o UPDATE)
        Return EjecutarTransaccion(lista)
    End Function


    Public Function modificarEstado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoGestor = CType(o, dNuevoGestor)
        Dim sql As String = "UPDATE Informe SET InformeEstadoId =" & obj.SOLICITUDESTADOID & " WHERE InformeId = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function modificarfechaEnvio(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoGestor = CType(o, dNuevoGestor)
        Dim sql As String = "UPDATE Informe SET InformeFechaFinalizado ='" & obj.FECHAENVIO & "' WHERE InformeId = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function
End Class
