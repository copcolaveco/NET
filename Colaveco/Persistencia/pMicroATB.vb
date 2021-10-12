Public Class pMicroATB
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMicroATB = CType(o, dMicroATB)
        Dim sql As String = "INSERT INTO micro_atb (id, micro, atb) VALUES (" & obj.ID & ", " & obj.MICRO & ", " & obj.ATB & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'micro_atb', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMicroATB = CType(o, dMicroATB)
        Dim sql As String = "UPDATE micro_atb SET micro = " & obj.MICRO & ", atb = " & obj.ATB & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'micro_atb', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMicroATB = CType(o, dMicroATB)
        Dim sql As String = "DELETE FROM micro_atb WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'micro_atb', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dMicroATB
        Dim obj As dMicroATB = CType(o, dMicroATB)
        Dim m As New dMicroATB
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, micro, atb FROM micro_atb WHERE  id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                m.ID = CType(unaFila.Item(0), Integer)
                m.MICRO = CType(unaFila.Item(1), Integer)
                m.ATB = CType(unaFila.Item(2), Integer)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, micro, atb FROM micro_atb ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMicroATB
                    m.ID = CType(unaFila.Item(0), Integer)
                    m.MICRO = CType(unaFila.Item(1), Integer)
                    m.ATB = CType(unaFila.Item(2), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxmicro(ByVal idaislam As Integer) As ArrayList
        Dim sql As String = "SELECT id, micro, atb FROM micro_atb WHERE micro = " & idaislam & " ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMicroATB
                    m.ID = CType(unaFila.Item(0), Integer)
                    m.MICRO = CType(unaFila.Item(1), Integer)
                    m.ATB = CType(unaFila.Item(2), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
