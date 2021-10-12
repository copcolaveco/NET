Public Class pSesion
    Inherits Conectoras.ConexionMySQL
    Public Function buscarUltimaSesion(ByVal s As dSesion) As dSesion
        Dim sql As String = "SELECT s_id, s_inicio, DATE_FORMAT(s_fin, '%d/%m/%Y %H:%i:%s'), u_id FROM sesion WHERE s_fin IS NULL AND u_id = " & s.Usuario.ID & " ORDER BY s_id DESC"
        Dim ds As DataSet = EjecutarSQL(sql)
        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow = ds.Tables(0).Rows(0)

                s.ID = CType(unaFila.Item(0), Integer)
                s.Inicio = CType(unaFila.Item(1), Date)
                Try
                    s.Fin = CType(unaFila.Item(2), Date)
                Catch ex As Exception
                    s.Fin = Nothing
                End Try

                Dim u As New dUsuario
                u.ID = CType(unaFila.Item(3), Integer)
                u = u.buscar
                s.Usuario = u

            End If
        End If
        Return s
    End Function
    Public Function abrirSesion(ByVal s As dSesion)
        Dim sql As String = "INSERT INTO sesion (s_inicio, u_id) VALUES (now(), " & s.Usuario.ID & ")"
        Dim lista As New ArrayList : lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function cerrarSesion(ByVal s As dSesion)
        Dim sql As String = "UPDATE sesion SET s_fin = now(), s_cerrada = 1 WHERE s_id = " & s.ID
        Dim lista As New ArrayList : lista.Add(sql)
        Return ejecutartransaccion(lista)
    End Function
End Class
