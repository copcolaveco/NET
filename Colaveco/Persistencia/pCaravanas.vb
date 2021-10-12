Public Class pCaravanas
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCaravanas = CType(o, dCaravanas)
        Dim sql As String = "INSERT INTO caravanas (id, ficha, numero, caravana) VALUES (" & obj.ID & "," & obj.FICHA & ", '" & obj.NUMERO & "', '" & obj.CARAVANA & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCaravanas = CType(o, dCaravanas)
        Dim sql As String = "UPDATE caravanas SET ficha= " & obj.FICHA & ", numero = '" & obj.NUMERO & "', caravana = '" & obj.CARAVANA & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCaravanas = CType(o, dCaravanas)
        Dim sql As String = "DELETE FROM caravanas WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminarxficha(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCaravanas = CType(o, dCaravanas)
        Dim sql As String = "DELETE FROM caravanas WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminartodo(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCaravanas = CType(o, dCaravanas)
        Dim sql As String = "DELETE FROM caravanas"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'caravanas', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCaravanas
        Dim obj As dCaravanas = CType(o, dCaravanas)
        Dim l As New dCaravanas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, numero, caravana FROM caravanas WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FICHA = CType(unaFila.Item(1), Long)
                l.NUMERO = CType(unaFila.Item(2), String)
                l.CARAVANA = CType(unaFila.Item(3), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, numero, caravana FROM caravanas"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCaravanas
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.NUMERO = CType(unaFila.Item(2), String)
                    l.CARAVANA = CType(unaFila.Item(3), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxficha(ByVal ficha As Long) As ArrayList
        Dim sql As String = "SELECT id, ficha, numero, caravana FROM caravanas WHERE ficha = " & ficha & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCaravanas
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.NUMERO = CType(unaFila.Item(2), String)
                    l.CARAVANA = CType(unaFila.Item(3), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
