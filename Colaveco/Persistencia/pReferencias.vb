Public Class pReferencias
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dReferencias = CType(o, dReferencias)
        Dim sql As String = "INSERT INTO referencias (id, analisis, referencia1, referencia2) VALUES (" & obj.ID & ", " & obj.ANALISIS & ", '" & obj.REFERENCIA1 & "', '" & obj.REFERENCIA2 & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'referencias', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dReferencias = CType(o, dReferencias)
        Dim sql As String = "UPDATE referencias SET analisis = " & obj.ANALISIS & ", referencia1 = '" & obj.REFERENCIA1 & "', referencia2 = '" & obj.REFERENCIA2 & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'referencias', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dReferencias = CType(o, dReferencias)
        Dim sql As String = "DELETE FROM referencias WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'referencias', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dReferencias
        Dim obj As dReferencias = CType(o, dReferencias)
        Dim l As New dReferencias
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, analisis, referencia1, referencia2 FROM referencias WHERE analisis = " & obj.ANALISIS & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.ANALISIS = CType(unaFila.Item(1), Integer)
                l.REFERENCIA1 = CType(unaFila.Item(2), String)
                l.REFERENCIA2 = CType(unaFila.Item(3), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, analisis, referencia1, referencia2 FROM referencias"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dReferencias
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.ANALISIS = CType(unaFila.Item(1), Integer)
                    l.REFERENCIA1 = CType(unaFila.Item(2), String)
                    l.REFERENCIA2 = CType(unaFila.Item(3), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
