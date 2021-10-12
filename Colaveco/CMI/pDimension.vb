Public Class pDimension
    Inherits Conectoras.ConexionMySQL_CMI
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dDimension = CType(o, dDimension)
        Dim sql As String = "INSERT INTO dimension (id, nombre, ano) VALUES (" & obj.ID & ", '" & obj.NOMBRE & "', " & obj.ANO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dDimension = CType(o, dDimension)
        Dim sql As String = "UPDATE dimension SET nombre = '" & obj.NOMBRE & "',ano = " & obj.ANO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarnombre(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dDimension = CType(o, dDimension)
        Dim sql As String = "UPDATE dimension SET nombre = '" & obj.NOMBRE & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dDimension = CType(o, dDimension)
        Dim sql As String = "DELETE FROM dimension WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dDimension
        Dim obj As dDimension = CType(o, dDimension)
        Dim d As New dDimension
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, ano FROM dimension WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                d.ID = CType(unaFila.Item(0), Long)
                d.NOMBRE = CType(unaFila.Item(1), String)
                d.ANO = CType(unaFila.Item(2), Integer)
                Return d
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, nombre, ano FROM dimension ORDER by ano DESC, nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim d As New dDimension
                    d.ID = CType(unaFila.Item(0), Long)
                    d.NOMBRE = CType(unaFila.Item(1), String)
                    d.ANO = CType(unaFila.Item(2), Integer)
                    Lista.Add(d)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, nombre, ano FROM dimension WHERE ano = " & ano & " ORDER by ano DESC, nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim d As New dDimension
                    d.ID = CType(unaFila.Item(0), Long)
                    d.NOMBRE = CType(unaFila.Item(1), String)
                    d.ANO = CType(unaFila.Item(2), Integer)
                    Lista.Add(d)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
