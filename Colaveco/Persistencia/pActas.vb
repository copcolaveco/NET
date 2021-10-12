Public Class pActas
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActas = CType(o, dActas)
        Dim sql As String = "INSERT INTO actas (id, numero, fecha, hora, grupo, lugar, presentes) VALUES (" & obj.ID & ", '" & obj.NUMERO & "', '" & obj.FECHA & "', '" & obj.HORA & "', " & obj.GRUPO & ", '" & obj.LUGAR & "','" & obj.PRESENTES & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'actas', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActas = CType(o, dActas)
        Dim sql As String = "UPDATE actas SET numero ='" & obj.NUMERO & "', fecha= '" & obj.FECHA & "',hora= '" & obj.HORA & "', grupo=" & obj.GRUPO & ", lugar= '" & obj.LUGAR & "', presentes= '" & obj.PRESENTES & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'actas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActas = CType(o, dActas)
        Dim sql As String = "DELETE FROM actas WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'actas', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dActas
        Dim obj As dActas = CType(o, dActas)
        Dim p As New dActas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, numero, fecha, hora, grupo, lugar, presentes FROM actas WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.NUMERO = CType(unaFila.Item(1), String)
                p.FECHA = CType(unaFila.Item(2), String)
                p.HORA = CType(unaFila.Item(3), String)
                p.GRUPO = CType(unaFila.Item(4), Integer)
                p.LUGAR = CType(unaFila.Item(5), String)
                p.PRESENTES = CType(unaFila.Item(6), String)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimoid(ByVal o As Object) As dActas
        Dim obj As dActas = CType(o, dActas)
        Dim a As New dActas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id FROM actas where id = (SELECT MAX(id) FROM actas)")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, numero, fecha, hora, grupo, lugar, presentes FROM actas ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActas
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NUMERO = CType(unaFila.Item(1), String)
                    p.FECHA = CType(unaFila.Item(2), String)
                    p.HORA = CType(unaFila.Item(3), String)
                    p.GRUPO = CType(unaFila.Item(4), Integer)
                    p.LUGAR = CType(unaFila.Item(5), String)
                    p.PRESENTES = CType(unaFila.Item(6), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, numero, fecha, hora, grupo, lugar, presentes FROM actas WHERE fecha BETWEEN '" & desde & "' AND '" & hasta & "' ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActas
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NUMERO = CType(unaFila.Item(1), String)
                    p.FECHA = CType(unaFila.Item(2), String)
                    p.HORA = CType(unaFila.Item(3), String)
                    p.GRUPO = CType(unaFila.Item(4), Integer)
                    p.LUGAR = CType(unaFila.Item(5), String)
                    p.PRESENTES = CType(unaFila.Item(6), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxgrupo(ByVal idgrupo As Integer) As ArrayList
        Dim sql As String = "SELECT id, numero, fecha, hora, grupo, lugar, presentes FROM actas WHERE grupo = " & idgrupo & " ORDER BY fecha DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActas
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NUMERO = CType(unaFila.Item(1), String)
                    p.FECHA = CType(unaFila.Item(2), String)
                    p.HORA = CType(unaFila.Item(3), String)
                    p.GRUPO = CType(unaFila.Item(4), Integer)
                    p.LUGAR = CType(unaFila.Item(5), String)
                    p.PRESENTES = CType(unaFila.Item(6), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxgrupoxano(ByVal grupo As Integer, ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, numero, fecha, hora, grupo, lugar, presentes FROM actas WHERE grupo = " & grupo & " AND YEAR(fecha) = " & ano & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActas
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NUMERO = CType(unaFila.Item(1), String)
                    p.FECHA = CType(unaFila.Item(2), String)
                    p.HORA = CType(unaFila.Item(3), String)
                    p.GRUPO = CType(unaFila.Item(4), Integer)
                    p.LUGAR = CType(unaFila.Item(5), String)
                    p.PRESENTES = CType(unaFila.Item(6), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechaxgrupo(ByVal desde As String, ByVal hasta As String, ByVal idgrupo As Integer) As ArrayList
        Dim sql As String = "SELECT id, numero, fecha, hora, grupo, lugar, presentes FROM actas WHERE grupo = " & idgrupo & " AND fecha BETWEEN '" & desde & "' AND '" & hasta & "' ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActas
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NUMERO = CType(unaFila.Item(1), String)
                    p.FECHA = CType(unaFila.Item(2), String)
                    p.HORA = CType(unaFila.Item(3), String)
                    p.GRUPO = CType(unaFila.Item(4), Integer)
                    p.LUGAR = CType(unaFila.Item(5), String)
                    p.PRESENTES = CType(unaFila.Item(6), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
