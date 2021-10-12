Public Class pCrioscopia_Medias
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Medias = CType(o, dCrioscopia_Medias)
        Dim sql As String = "INSERT INTO crioscopia_medias (id, fecha, c1, c2) VALUES (" & obj.ID & ", '" & obj.FECHA & "'," & obj.C1 & "," & obj.C2 & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_medias', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Medias = CType(o, dCrioscopia_Medias)
        Dim sql As String = "UPDATE crioscopia_medias SET fecha = '" & obj.FECHA & "', c1 = " & obj.C1 & ",c2 = " & obj.C2 & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_medias', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Medias = CType(o, dCrioscopia_Medias)
        Dim sql As String = "DELETE FROM crioscopia_medias WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_medias', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dCrioscopia_Medias
        Dim obj As dCrioscopia_Medias = CType(o, dCrioscopia_Medias)
        Dim c As New dCrioscopia_Medias
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, c1, c2 FROM crioscopia_medias WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.C1 = CType(unaFila.Item(2), Integer)
                c.C2 = CType(unaFila.Item(3), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimo(ByVal o As Object) As dCrioscopia_Medias
        Dim obj As dCrioscopia_Medias = CType(o, dCrioscopia_Medias)
        Dim c As New dCrioscopia_Medias
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, c1, c2 FROM crioscopia_medias where id = (SELECT MAX(id) FROM crioscopia_medias)")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.C1 = CType(unaFila.Item(2), Integer)
                c.C2 = CType(unaFila.Item(3), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, c1, c2 FROM crioscopia_medias order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCrioscopia_Medias
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.C1 = CType(unaFila.Item(2), Integer)
                    c.C2 = CType(unaFila.Item(3), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
