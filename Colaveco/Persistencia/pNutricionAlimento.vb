Public Class pNutricionAlimento
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNutricionAlimento = CType(o, dNutricionAlimento)
        Dim sql As String = "INSERT INTO nutricion_alimento (id, idclase, nombre) VALUES (" & obj.ID & "," & obj.IDCLASE & ", '" & obj.NOMBRE & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nutricion_alimento', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNutricionAlimento = CType(o, dNutricionAlimento)
        Dim sql As String = "UPDATE nutricion_alimento SET idclase = " & obj.IDCLASE & " , nombre = '" & obj.NOMBRE & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nutricion_alimento', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNutricionAlimento = CType(o, dNutricionAlimento)
        Dim sql As String = "DELETE FROM nutricion_alimento WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nutricion_alimento', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNutricionAlimento
        Dim obj As dNutricionAlimento = CType(o, dNutricionAlimento)
        Dim l As New dNutricionAlimento
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idclase, nombre FROM nutricion_alimento WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.IDCLASE = CType(unaFila.Item(1), Integer)
                l.NOMBRE = CType(unaFila.Item(2), String)

                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idclase, nombre FROM nutricion_alimento ORDER BY nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dNutricionAlimento
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.IDCLASE = CType(unaFila.Item(1), Integer)
                    l.NOMBRE = CType(unaFila.Item(2), String)

                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporclase(ByVal idclase As Integer) As ArrayList
        Dim sql As String = "SELECT id, idclase, nombre FROM nutricion_alimento WHERE idclase = " & idclase & " ORDER BY nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dNutricionAlimento
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.IDCLASE = CType(unaFila.Item(1), Integer)
                    l.NOMBRE = CType(unaFila.Item(2), String)

                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
