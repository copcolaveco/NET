Public Class pPaquetes
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPaquetes = CType(o, dPaquetes)
        Dim sql As String = "INSERT INTO paquetes (id, idpadre, idhijo, preciopadre) VALUES (" & obj.ID & ", " & obj.IDPADRE & ", " & obj.IDHIJO & ", " & obj.PRECIOPADRE & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'paquetes', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPaquetes = CType(o, dPaquetes)
        Dim sql As String = "UPDATE paquetes SET idpadre = " & obj.IDPADRE & ", idhijo = " & obj.IDHIJO & ", preciopadre = " & obj.PRECIOPADRE & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'paquetes', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPaquetes = CType(o, dPaquetes)
        Dim sql As String = "DELETE FROM paquetes WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'paquetes', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPaquetes
        Dim obj As dPaquetes = CType(o, dPaquetes)
        Dim l As New dPaquetes
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idpadre, idhijo, preciopadre FROM paquetes WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.IDPADRE = CType(unaFila.Item(1), Integer)
                l.IDHIJO = CType(unaFila.Item(2), Integer)
                l.PRECIOPADRE = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxidpadre(ByVal o As Object) As dPaquetes
        Dim obj As dPaquetes = CType(o, dPaquetes)
        Dim l As New dPaquetes
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idpadre, idhijo, preciopadre FROM paquetes WHERE idpadre = " & obj.IDPADRE & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.IDPADRE = CType(unaFila.Item(1), Integer)
                l.IDHIJO = CType(unaFila.Item(2), Integer)
                l.PRECIOPADRE = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idpadre, idhijo, preciopadre FROM paquetes"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dPaquetes
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.IDPADRE = CType(unaFila.Item(1), Integer)
                    l.IDHIJO = CType(unaFila.Item(2), Integer)
                    l.PRECIOPADRE = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxpadre(ByVal idp As Integer) As ArrayList
        Dim sql As String = "SELECT id, idpadre, idhijo, preciopadre FROM paquetes WHERE idpadre = " & idp & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dPaquetes
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.IDPADRE = CType(unaFila.Item(1), Integer)
                    l.IDHIJO = CType(unaFila.Item(2), Integer)
                    l.PRECIOPADRE = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
