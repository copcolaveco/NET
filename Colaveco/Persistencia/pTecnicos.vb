Public Class pTecnicos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dtecnicos = CType(o, dtecnicos)
        Dim sql As String = "INSERT INTO tecnicos (id, nombre, direccion, telefono, celular, mail) VALUES (" & obj.ID & ", '" & obj.NOMBRE & "', '" & obj.DIRECCION & "','" & obj.TELEFONO & "','" & obj.CELULAR & "','" & obj.EMAIL & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'tecnicos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dTecnicos = CType(o, dTecnicos)
        Dim sql As String = "UPDATE tecnicos SET nombre ='" & obj.NOMBRE & "', direccion ='" & obj.DIRECCION & "', telefono ='" & obj.TELEFONO & "', celular ='" & obj.CELULAR & "', mail ='" & obj.EMAIL & "' WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'tecnicos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dTecnicos = CType(o, dTecnicos)
        Dim sql As String = "DELETE FROM tecnicos WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'tecnicos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dTecnicos
        Dim obj As dTecnicos = CType(o, dTecnicos)
        Dim t As New dTecnicos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, ifnull(direccion,''), ifnull(telefono,''), ifnull(celular,''), ifnull(mail,'') FROM tecnicos WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                t.ID = CType(unaFila.Item(0), Long)
                t.NOMBRE = CType(unaFila.Item(1), String)
                t.DIRECCION = CType(unaFila.Item(2), String)
                t.TELEFONO = CType(unaFila.Item(3), String)
                t.CELULAR = CType(unaFila.Item(4), String)
                t.EMAIL = CType(unaFila.Item(5), String)
                Return t
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ifnull(nombre,''), ifnull(direccion,''), ifnull(telefono,''),ifnull(celular,''), ifnull(mail,'') FROM tecnicos order by nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim t As New dTecnicos
                    t.ID = CType(unaFila.Item(0), Long)
                    t.NOMBRE = CType(unaFila.Item(1), String)
                    t.DIRECCION = CType(unaFila.Item(2), String)
                    t.TELEFONO = CType(unaFila.Item(3), String)
                    t.CELULAR = CType(unaFila.Item(4), String)
                    t.EMAIL = CType(unaFila.Item(5), String)
                    Lista.Add(t)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorNombre(ByVal pNombre As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, ifnull(nombre,''),  ifnull(direccion,''), ifnull(telefono,''), ifnull(celular,''), ifnull(mail,'') FROM tecnicos WHERE nombre LIKE '%" & pNombre & "%'"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim t As New dTecnicos()
                    t.ID = CType(unaFila.Item(0), Long)
                    t.NOMBRE = CType(unaFila.Item(1), String)
                    t.DIRECCION = CType(unaFila.Item(2), String)
                    t.TELEFONO = CType(unaFila.Item(3), String)
                    t.CELULAR = CType(unaFila.Item(4), String)
                    t.EMAIL = CType(unaFila.Item(5), String)
                    listaResultado.Add(t)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
End Class
