Public Class pLocalidad
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLocalidad = CType(o, dLocalidad)
        Dim sql As String = "INSERT INTO localidad (ID, Nombre, ID_Departamento) VALUES (" & obj.ID & ", '" & obj.NOMBRE & "', " & obj.IDDEPARTAMENTO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'localidad', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLocalidad = CType(o, dLocalidad)
        Dim sql As String = "UPDATE localidad SET Nombre = '" & obj.NOMBRE & "', ID_DEPARTAMENTO = " & obj.IDDEPARTAMENTO & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'localidad', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLocalidad = CType(o, dLocalidad)
        Dim sql As String = "DELETE FROM Localidad WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'localidad', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dLocalidad
        Dim obj As dLocalidad = CType(o, dLocalidad)
        Dim l As New dLocalidad
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT ID, Nombre, ID_DEPARTAMENTO FROM localidad WHERE ID = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.NOMBRE = CType(unaFila.Item(1), String)
                l.IDDEPARTAMENTO = CType(unaFila.Item(2), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT ID, Nombre, ID_DEPARTAMENTO FROM localidad order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dLocalidad
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.NOMBRE = CType(unaFila.Item(1), String)
                    l.IDDEPARTAMENTO = CType(unaFila.Item(2), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpordepartamento(ByVal texto As Integer) As ArrayList
        Dim sql As String = ("SELECT id, nombre, id_departamento FROM localidad where id_departamento = " & texto & " order by nombre asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dLocalidad
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.NOMBRE = CType(unaFila.Item(1), String)
                    l.IDDEPARTAMENTO = CType(unaFila.Item(2), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
