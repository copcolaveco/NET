Public Class pNoticias
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoticias = CType(o, dNoticias)
        Dim sql As String = "INSERT INTO noticias (id, descripcion, mes, dia, diario) VALUES (" & obj.ID & ", '" & obj.DESCRIPCION & "', " & obj.MES & ", " & obj.DIA & ", " & obj.DIARIO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'noticias', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoticias = CType(o, dNoticias)
        Dim sql As String = "UPDATE noticias SET descripcion = '" & obj.DESCRIPCION & "',mes = " & obj.MES & ", dia=" & obj.DIA & ", diario=" & obj.DIARIO & " WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'noticias', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoticias = CType(o, dNoticias)
        Dim sql As String = "DELETE FROM noticias WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'noticias', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNoticias
        Dim obj As dNoticias = CType(o, dNoticias)
        Dim n As New dNoticias
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, descripcion, mes, dia, diario FROM noticias WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Integer)
                n.DESCRIPCION = CType(unaFila.Item(1), String)
                n.MES = CType(unaFila.Item(2), Integer)
                n.DIA = CType(unaFila.Item(3), Integer)
                n.DIARIO = CType(unaFila.Item(4), Integer)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, descripcion, mes, dia, diario FROM noticias order by mes asc, dia asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNoticias
                    n.ID = CType(unaFila.Item(0), Integer)
                    n.DESCRIPCION = CType(unaFila.Item(1), String)
                    n.MES = CType(unaFila.Item(2), Integer)
                    n.DIA = CType(unaFila.Item(3), Integer)
                    n.DIARIO = CType(unaFila.Item(4), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal dia As Integer, ByVal mes As Integer) As ArrayList
        Dim sql As String = "SELECT id, descripcion, mes, dia, diario FROM noticias WHERE mes = " & mes & " and dia = " & dia & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNoticias
                    n.ID = CType(unaFila.Item(0), Integer)
                    n.DESCRIPCION = CType(unaFila.Item(1), String)
                    n.MES = CType(unaFila.Item(2), Integer)
                    n.DIA = CType(unaFila.Item(3), Integer)
                    n.DIARIO = CType(unaFila.Item(4), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
