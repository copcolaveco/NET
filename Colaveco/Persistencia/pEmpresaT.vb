Public Class pEmpresaT
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEmpresaT = CType(o, dEmpresaT)
        Dim sql As String = "INSERT INTO empresatrans (id, nombre, direccion, telefono) VALUES (" & obj.ID & ", '" & obj.NOMBRE & "', '" & obj.DIRECCION & "', '" & obj.TELEFONO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'empresatrans', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEmpresaT = CType(o, dEmpresaT)
        Dim sql As String = "UPDATE empresatrans SET nombre = '" & obj.NOMBRE & "', direccion = '" & obj.DIRECCION & "', telefono = '" & obj.TELEFONO & "' WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'empresatrans', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEmpresaT = CType(o, dEmpresaT)
        Dim sql As String = "DELETE FROM empresatrans WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'empresatrans', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dEmpresaT
        Dim obj As dEmpresaT = CType(o, dEmpresaT)
        Dim l As New dEmpresaT
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, direccion, telefono FROM empresatrans WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.NOMBRE = CType(unaFila.Item(1), String)
                l.DIRECCION = CType(unaFila.Item(2), String)
                l.TELEFONO = CType(unaFila.Item(3), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, nombre, direccion, telefono FROM empresatrans order by nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dEmpresaT
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.NOMBRE = CType(unaFila.Item(1), String)
                    l.DIRECCION = CType(unaFila.Item(2), String)
                    l.TELEFONO = CType(unaFila.Item(3), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
