Public Class pFactur
    Inherits Conectoras.ConexionMySQL_facturacion

    Public Function listarxfecha(ByVal nrofac As Long) As ArrayList
        Dim sql As String = "SELECT facnro, facpdf FROM factur WHERE facnro = " & nrofac & " "
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dFactur
                    l.FACNRO = CType(unaFila.Item(0), Long)
                    l.FACPDF = CType(unaFila.Item(1), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscar(ByVal o As Object) As dFactur
        Dim obj As dFactur = CType(o, dFactur)
        Dim l As New dFactur
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT facnro, facpdf FROM factur WHERE facnro = " & obj.FACNRO & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.FACNRO = CType(unaFila.Item(0), Long)
                l.FACPDF = CType(unaFila.Item(1), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
