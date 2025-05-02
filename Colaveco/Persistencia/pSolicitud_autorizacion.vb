Public Class pSolicitud_autorizacion
    Inherits Conectoras.ConexionMySQL

    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dSolicitud_Autorizacion = CType(o, dSolicitud_Autorizacion)
        Dim sql As String = "INSERT INTO solicitud_autorizacion (solicitudanalisis_id, usuario_autoriza_id, observaciones, fecha) VALUES (" & obj.SOLICITUDANALISIS_ID & ", " & obj.USUARIO_AUTORIZA_ID & ", '" & obj.OBSERVACIONES & "', '" & obj.FECHA & "')"
        Dim lista As New ArrayList
        lista.Add(sql)
        Try
            Return EjecutarTransaccion(lista)
        Catch ex As Exception
            MsgBox("Error al guardar la autorización: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function listarPorFiltros(fechaDesde As String, fechaHasta As String, Optional solicitudId As Long = 0) As ArrayList
        Dim sql As String = "SELECT solicitudanalisis_id, usuario_autoriza_id, fecha, observaciones FROM solicitud_autorizacion WHERE fecha >= '" & fechaDesde & "' AND fecha <= '" & fechaHasta & "'"
        If solicitudId > 0 Then
            sql &= " AND solicitudanalisis_id = " & solicitudId
        End If
        sql &= " ORDER BY fecha DESC"

        Try
            Dim ds As New DataSet
            ds = Me.EjecutarSQL(sql)
            Dim lista As New ArrayList()

            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                For Each f As DataRow In ds.Tables(0).Rows
                    Dim s As New dSolicitud_Autorizacion()
                    s.SOLICITUDANALISIS_ID = CType(f.Item(0), Long)
                    s.USUARIO_AUTORIZA_ID = CType(f.Item(1), Long)
                    s.FECHA = CType(f.Item(2), String)
                    s.OBSERVACIONES = CType(f.Item(3), String)
                    lista.Add(s)
                Next
            End If

            Return lista
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


End Class
