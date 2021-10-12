Public Class pMovCte
    Inherits Conectoras.ConexionMySQL_facturacion
   
    Public Function listarxcli(ByVal idcli As Long) As ArrayList
        Dim sql As String = "SELECT mccvto, clicod, mccimp, mccpag, mcccod, mcccmp FROM movcte WHERE clicod = " & idcli & " AND mccpag < mccimp AND mcccod =1"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMovCte
                    l.MCCVTO = CType(unaFila.Item(0), String)
                    l.CLICOD = CType(unaFila.Item(1), Long)
                    l.MCCIMP = CType(unaFila.Item(2), Double)
                    l.MCCPAG = CType(unaFila.Item(3), Double)
                    l.MCCCOD = CType(unaFila.Item(4), Integer)
                    l.MCCCMP = CType(unaFila.Item(5), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function saldosxcli(ByVal idcli As Long) As ArrayList
        Dim sql As String = "SELECT mccvto, clicod, mccimp, mccpag, mcccod, mcccmp FROM movcte WHERE clicod = " & idcli & " "
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMovCte
                    l.MCCVTO = CType(unaFila.Item(0), String)
                    l.CLICOD = CType(unaFila.Item(1), Long)
                    l.MCCIMP = CType(unaFila.Item(2), Double)
                    l.MCCPAG = CType(unaFila.Item(3), Double)
                    l.MCCCOD = CType(unaFila.Item(4), Integer)
                    l.MCCCMP = CType(unaFila.Item(5), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxcomprobante(ByVal o As Object) As dMovCte
        Dim obj As dMovCte = CType(o, dMovCte)
        Dim l As New dMovCte
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT mccvto, clicod, mccimp, mccpag, mcccod, mcccmp FROM movcte WHERE mcccmp = " & obj.MCCCMP & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.MCCVTO = CType(unaFila.Item(0), String)
                l.CLICOD = CType(unaFila.Item(1), Long)
                l.MCCIMP = CType(unaFila.Item(2), Double)
                l.MCCPAG = CType(unaFila.Item(3), Double)
                l.MCCCOD = CType(unaFila.Item(4), Integer)
                l.MCCCMP = CType(unaFila.Item(5), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
