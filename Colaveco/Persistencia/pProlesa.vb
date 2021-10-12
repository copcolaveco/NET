Public Class pProlesa
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProlesa = CType(o, dProlesa)
        Dim sql As String = "INSERT INTO prolesa (id, nrosuc, sucursal, direccion, telefono, encargado, mail) VALUES (" & obj.ID & ", " & obj.NROSUC & ", '" & obj.SUCURSAL & "',  '" & obj.DIRECCION & "','" & obj.TELEFONO & "', '" & obj.ENCARGADO & "', '" & obj.MAIL & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'prolesa', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProlesa = CType(o, dProlesa)
        Dim sql As String = "UPDATE prolesa SET nrosuc = " & obj.NROSUC & ", sucursal = '" & obj.SUCURSAL & "', direccion = '" & obj.DIRECCION & "', telefono = '" & obj.TELEFONO & "', encargado = '" & obj.ENCARGADO & "', mail = '" & obj.MAIL & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'prolesa', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProlesa = CType(o, dProlesa)
        Dim sql As String = "DELETE FROM prolesa WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'prolesa', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dProlesa
        Dim obj As dProlesa = CType(o, dProlesa)
        Dim l As New dProlesa
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nrosuc, sucursal, direccion, telefono, encargado, mail FROM prolesa WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.NROSUC = CType(unaFila.Item(1), Integer)
                l.SUCURSAL = CType(unaFila.Item(2), String)
                l.DIRECCION = CType(unaFila.Item(3), String)
                l.TELEFONO = CType(unaFila.Item(4), String)
                l.ENCARGADO = CType(unaFila.Item(5), String)
                l.MAIL = CType(unaFila.Item(6), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxsuc(ByVal o As Object) As dProlesa
        Dim obj As dProlesa = CType(o, dProlesa)
        Dim l As New dProlesa
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nrosuc, sucursal, direccion, telefono, encargado, mail FROM prolesa WHERE nrosuc = " & obj.NROSUC & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.NROSUC = CType(unaFila.Item(1), Integer)
                l.SUCURSAL = CType(unaFila.Item(2), String)
                l.DIRECCION = CType(unaFila.Item(3), String)
                l.TELEFONO = CType(unaFila.Item(4), String)
                l.ENCARGADO = CType(unaFila.Item(5), String)
                l.MAIL = CType(unaFila.Item(6), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, nrosuc, sucursal, direccion, telefono, encargado, mail FROM prolesa"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dProlesa
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.NROSUC = CType(unaFila.Item(1), Integer)
                    l.SUCURSAL = CType(unaFila.Item(2), String)
                    l.DIRECCION = CType(unaFila.Item(3), String)
                    l.TELEFONO = CType(unaFila.Item(4), String)
                    l.ENCARGADO = CType(unaFila.Item(5), String)
                    l.MAIL = CType(unaFila.Item(6), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
