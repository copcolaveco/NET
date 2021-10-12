Public Class pGraficaRC
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dGraficaRC = CType(o, dGraficaRC)
        Dim sql As String = "INSERT INTO grafica_rc (id, ficha, libre, posible, probable) VALUES (" & obj.ID & ", " & obj.FICHA & ", " & obj.LIBRE & ", " & obj.POSIBLE & ", " & obj.PROBABLE & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dGraficaRC = CType(o, dGraficaRC)
        Dim sql As String = "UPDATE grafica_rc SET ficha = " & obj.FICHA & ",libre = " & obj.LIBRE & ",posible = " & obj.POSIBLE & ",probable = " & obj.PROBABLE & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dGraficaRC = CType(o, dGraficaRC)
        Dim sql As String = "DELETE FROM grafica_rc WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dGraficaRC
        Dim obj As dGraficaRC = CType(o, dGraficaRC)
        Dim l As New dGraficaRC
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, libre, posible, probable FROM grafica_rc WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FICHA = CType(unaFila.Item(1), Long)
                l.LIBRE = CType(unaFila.Item(2), Double)
                l.POSIBLE = CType(unaFila.Item(3), Double)
                l.PROBABLE = CType(unaFila.Item(4), Double)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, libre, posible, probable FROM grafica_rc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dGraficaRC
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.LIBRE = CType(unaFila.Item(2), Double)
                    l.POSIBLE = CType(unaFila.Item(3), Double)
                    l.PROBABLE = CType(unaFila.Item(4), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
