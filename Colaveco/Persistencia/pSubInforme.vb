Public Class pSubInforme
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSubInforme = CType(o, dSubInforme)
        Dim sql As String = "INSERT INTO subtiposdeinformes (id, nombre, idtipoinforme, generaplanilla, titulo) VALUES (" & obj.ID & ", '" & obj.NOMBRE & "', " & obj.IDTIPOINFORME & ", " & obj.GENERARPLANILLA & ", '" & obj.TITULO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'subtiposdeinformes', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSubInforme = CType(o, dSubInforme)
        Dim sql As String = "UPDATE subtiposdeinformes SET nombre = '" & obj.NOMBRE & "', idtipoinforme=" & obj.IDTIPOINFORME & ", generaplanilla=" & obj.GENERARPLANILLA & ", titulo='" & obj.TITULO & "' WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'subtiposdeinformes', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSubInforme = CType(o, dSubInforme)
        Dim sql As String = "DELETE FROM subtiposdeinformes WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'subtiposdeinformes', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSubInforme
        Dim obj As dSubInforme = CType(o, dSubInforme)
        Dim s As New dSubInforme
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, idtipoinforme, generaplanilla, ifnull(titulo,'') FROM subtiposdeinformes WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Integer)
                s.NOMBRE = CType(unaFila.Item(1), String)
                s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                s.GENERARPLANILLA = CType(unaFila.Item(3), Integer)
                s.TITULO = CType(unaFila.Item(4), String)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, nombre, idtipoinforme, generaplanilla, ifnull(titulo,'') FROM subtiposdeinformes ORDER BY nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSubInforme
                    s.ID = CType(unaFila.Item(0), Integer)
                    s.NOMBRE = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.GENERARPLANILLA = CType(unaFila.Item(3), Integer)
                    s.TITULO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarportipoinforme(ByVal texto As Integer) As ArrayList
        Dim sql As String = ("SELECT id, nombre,idtipoinforme, generaplanilla, ifnull(titulo,'')FROM subtiposdeinformes where idtipoinforme = " & texto & " order by nombre asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSubInforme
                    s.ID = CType(unaFila.Item(0), Integer)
                    s.NOMBRE = CType(unaFila.Item(1), String)
                    s.IDTIPOINFORME = CType(unaFila.Item(2), Integer)
                    s.GENERARPLANILLA = CType(unaFila.Item(3), Integer)
                    s.TITULO = CType(unaFila.Item(4), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
