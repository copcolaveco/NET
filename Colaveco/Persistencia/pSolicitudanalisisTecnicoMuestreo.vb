Public Class pSolicitudanalisisTecnicoMuestreo
    Inherits Conectoras.ConexionMySQL

    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dSolicitudanalisis_TecMuestreo = CType(o, dSolicitudanalisis_TecMuestreo)
        Dim sql As String = "INSERT INTO solicitudanalisis_tecnicomuestreo (id_sol_tecmuestreo, id_solicitudanalisis, id_tecnicomuestreo) VALUES (" & obj.ID_SOLICITUDANALISIS_TECMUESTREO & ", '" & obj.ID_SOLICITUDANALISIS & "', '" & obj.ID_TECNICOMUESTREO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
End Class
