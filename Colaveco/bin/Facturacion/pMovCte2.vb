Public Class pMovCte2
    Inherits Conectoras.ConexionMySQL_facturacion

    Public Function listarxfecha(ByVal fecd As String) As ArrayList
        Dim sql As String = "SELECT mccnro, mccfch, mccvto, doccod, mccdoc, mccdes, clicod, mccimp, mccpag, mcccod, mcctip, mcccmp FROM movcte WHERE mccfev = '" & fecd & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMovCte2
                    l.MCCNRO = CType(unaFila.Item(0), Long)
                    l.MCCFCH = CType(unaFila.Item(1), String)
                    l.MCCVTO = CType(unaFila.Item(2), String)
                    l.DOCCOD = CType(unaFila.Item(3), String)
                    l.MCCDOC = CType(unaFila.Item(4), Long)
                    l.MCCDES = CType(unaFila.Item(5), String)
                    l.CLICOD = CType(unaFila.Item(6), Long)
                    l.MCCIMP = CType(unaFila.Item(7), Double)
                    l.MCCPAG = CType(unaFila.Item(8), Double)
                    l.MCCCOD = CType(unaFila.Item(9), Integer)
                    l.MCCTIP = CType(unaFila.Item(10), String)
                    l.MCCCMP = CType(unaFila.Item(11), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarentrefechas(ByVal fecd As String, ByVal fech As String) As ArrayList
        Dim sql As String = "SELECT mccnro, mccfch, mccvto, doccod, mccdoc, mccdes, clicod, mccimp, mccpag, mcccod, mcctip, mcccmp FROM movcte WHERE mccfch BETWEEN '" & fecd & "' AND '" & fech & "' "
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMovCte2
                    l.MCCNRO = CType(unaFila.Item(0), Long)
                    l.MCCFCH = CType(unaFila.Item(1), String)
                    l.MCCVTO = CType(unaFila.Item(2), String)
                    l.DOCCOD = CType(unaFila.Item(3), String)
                    l.MCCDOC = CType(unaFila.Item(4), Long)
                    l.MCCDES = CType(unaFila.Item(5), String)
                    l.CLICOD = CType(unaFila.Item(6), Long)
                    l.MCCIMP = CType(unaFila.Item(7), Double)
                    l.MCCPAG = CType(unaFila.Item(8), Double)
                    l.MCCCOD = CType(unaFila.Item(9), Integer)
                    l.MCCTIP = CType(unaFila.Item(10), String)
                    l.MCCCMP = CType(unaFila.Item(11), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxcliente(ByVal idcli As Integer) As ArrayList
        Dim sql As String = "SELECT mccnro, mccfch, mccvto, doccod, mccdoc, mccdes, clicod, mccimp, mccpag, mcccod, mcctip, mcccmp FROM movcte WHERE clicod = " & idcli & " "
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMovCte2
                    l.MCCNRO = CType(unaFila.Item(0), Long)
                    l.MCCFCH = CType(unaFila.Item(1), String)
                    l.MCCVTO = CType(unaFila.Item(2), String)
                    l.DOCCOD = CType(unaFila.Item(3), String)
                    l.MCCDOC = CType(unaFila.Item(4), Long)
                    l.MCCDES = CType(unaFila.Item(5), String)
                    l.CLICOD = CType(unaFila.Item(6), Long)
                    l.MCCIMP = CType(unaFila.Item(7), Double)
                    l.MCCPAG = CType(unaFila.Item(8), Double)
                    l.MCCCOD = CType(unaFila.Item(9), Integer)
                    l.MCCTIP = CType(unaFila.Item(10), String)
                    l.MCCCMP = CType(unaFila.Item(11), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
